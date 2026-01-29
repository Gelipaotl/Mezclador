using Mezclador.Models;
using Mezclador.Properties;
using Mezclador.UserConfig;
using Mezclador.Users;

namespace Mezclador
{
    public enum OrderStatus { NoOrder, InProcess, Completed, Canceled }
    public static class ControlOrdenes
    {
        public static bool ShowLogin = false;
        public static string Order { get; private set; } = string.Empty;
        public static OrdenModel SelectedOrder { get; private set; } = new();
        public static string RequiredAmount { get; private set; } = string.Empty;
        public static int RequiredProducts { get; private set; } = 0;
        public static int ActualCarga { get; private set; } = 0;
        public static Image? ActualImagen { get; private set; }
        //public static string ActualCantidadAPesar { get; private set; } = string.Empty;
        //public static InstruccionDataModel? ActualMaterialAPesar { get; private set; } = new();
        public static string CantidadLigeraAPesar { get; private set; } = string.Empty;
        public static InstruccionDataModel? MaterialLigeroAPesar { get; private set; } = new();
        public static string CantidadPesadaAPesar { get; private set; } = string.Empty;
        public static InstruccionDataModel? MaterialPesadoAPesar { get; private set; } = new();
        public static bool PesoLigeroOk { get; private set; }
        public static bool PesoPesadoOk { get; private set; }
        public static bool ReqPeso { get; private set; }
        public static bool CodigoLigeroOk { get; private set; } = false;
        public static bool CodigoPesadoOk { get; private set; } = false;
        public static ProductoModel SelectedProducto { get; private set; } = new();
        public static List<InstruccionDataModel>? Materials { get; private set; }
        public static List<InstruccionDataModel>? MaterialesLigeros { get; private set; }
        public static List<InstruccionDataModel>? MaterialesPesados { get; private set; }
        public static int Step { get; private set; } = 0;
        public static string? InstructionText { get; private set; } = string.Empty;
        public static string? InstructionLigeros { get; private set; } = string.Empty;
        public static string? InstructionPesados { get; private set; } = string.Empty;
        public static string? InstObjetivoPesado { get; private set; } = string.Empty;
        public static string? InstObjetivoLigero { get; private set; } = string.Empty;

        static System.Timers.Timer? timer;
        public static int idOrden = 0;
        public static int idCarga = 0;
        public static bool sequenceRunning = false;
        static bool sequenceBusy = false;

        //public static int SacosNecesarios = 0;
        //public static int SacosCargados = 0;
        //public static double SacoFraccion = 0.0;
        //public static bool SacoReady = false;

        public static int SacosLigerosNecesarios = 0;
        public static int SacosLigerosCargados = 0;
        public static double SacoLigeroFraccion = 0.0;
        public static bool SacoLigeroReady = false;

        public static int SacosPesadosNecesarios = 0;
        public static int SacosPesadosCargados = 0;
        public static double SacoPesadoFraccion = 0.0;
        public static bool SacoPesadoReady = false;
        //public static bool cancelOrder = false;
        //public static bool continueOrder = false;

        public static OrderStatus Status;
        public static void Start()
        {
            timer = new()
            {
                Interval = 100
            };
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }
        public static void ClearData()
        {
            ShowLogin = false;
            Order = "clear";
            SelectedOrder = new();
            RequiredAmount = string.Empty;
            RequiredProducts = 0;
            ActualCarga = 0;
            //ActualImagen
            //ActualCantidadAPesar = string.Empty;
            //ActualMaterialAPesar = new();
            CantidadLigeraAPesar = string.Empty;
            MaterialLigeroAPesar = new();
            CantidadPesadaAPesar = string.Empty;
            MaterialPesadoAPesar = new();
            PesoLigeroOk = false;
            PesoPesadoOk = false;
            CodigoLigeroOk = false;
            CodigoPesadoOk = false;

            SelectedProducto = new();
            Materials = new();
            MaterialesLigeros = new();
            MaterialesPesados = new();
            Step = 0;
            InstructionText = string.Empty;
            idOrden = 0;
            idCarga = 0;
            sequenceBusy = false;
            Status = OrderStatus.NoOrder;

            //SacoFraccion = 0.0;
            //SacosCargados = 0;
            //SacosNecesarios = 0;
            //SacoReady = false;

            SacoLigeroFraccion = 0.0;
            SacosLigerosCargados = 0;
            SacosLigerosNecesarios = 0;
            SacoLigeroReady = false;
            SacoPesadoFraccion = 0.0;
            SacosPesadosCargados = 0;
            SacosPesadosNecesarios = 0;
            SacoPesadoReady = false;
            //cancelOrder = false;
            //continueOrder = false;
        }
        public static void LoadRecipe(ProductoModel selectedProducto, List<InstruccionDataModel> products)
        {
            Step = 0;
            SelectedProducto = selectedProducto;
            Materials = products.Where(p => p.Habilitado).OrderBy(p => p.Paso).ToList();
            //MaterialesLigeros = Materials.Where(p => (!p.Saco && p.Cantidad < 10.0) || (p.Saco && p.PesoSaco < 10)).OrderBy(p => p.Paso).ToList();
            //MaterialesPesados = Materials.Where(p => (!p.Saco && p.Cantidad >= 10.0) || (p.Saco && p.PesoSaco >= 10)).OrderBy(p => p.Paso).ToList();
            MaterialesLigeros = Materials.Where(p => p.Ligera).OrderBy(p => p.Paso).ToList();
            MaterialesPesados = Materials.Where(p => p.Pesada).OrderBy(p => p.Paso).ToList();
            PesoLigeroOk = false;
        }
        public static void CloseOrder()
        {
            ConexionDB.UpdateOrderStatus(idOrden, OrderStatus.Canceled);
            ConexionDB.CancelCargas();
            ClearData();
        }
        public static void CancelOrder()
        {
            ConexionDB.DeleteCargas(idOrden);
            //ConexionDB.CancelCargas();
            ClearData();
        }

        public static void CreateOrder()
        {
            idOrden = ConexionDB.CreateOrder(ConexionDB.CrudType.Create, Order, RequiredAmount, RequiredProducts, SelectedProducto.Id);
            idCarga = ConexionDB.CreateCarga(ConexionDB.CrudType.Create, idOrden, Usuario.Id);
            GetActualCarga(idOrden);
        }

        public static void UpdateOrder(string cantidadRequerida, int productosRequeridos, OrderStatus status)
        {
            //idOrden = ConexionDB.CreateOrder(ConexionDB.CrudType.Create, Order, RequiredAmount, RequiredProducts, SelectedProducto.Id);
            //idCarga = ConexionDB.CreateCarga(ConexionDB.CrudType.Create, idOrden, Usuario.Id);
            //GetActualCarga(idOrden);
            ConexionDB.UpdateOrderAmount(idOrden, cantidadRequerida, productosRequeridos, status.ToString());
            Status = status;
        }
        public static int CreateCarga()
        {
            idCarga = 0;
            var cargas = ConexionDB.GetCargas(idOrden);

            //es para cuando cierran sesion y la vuelven a abrir para recordar la orden en que se quedaron
            // Verifica si la lista tiene al menos un elemento antes de acceder a cargas[0]
            if (cargas.Count > 0 && string.IsNullOrEmpty(cargas[0].Fin))
            {
                idCarga = cargas[0].Id;
            }
            if (idCarga == 0 && RequiredProducts > 0 && cargas.Count < RequiredProducts)
            {
                idCarga = ConexionDB.CreateCarga(ConexionDB.CrudType.Create, idOrden, Usuario.Id);
            }
            GetActualCarga(idOrden);
            return idCarga;
        }
        public static void GetActualCarga(int idOrden)
        {
            var cargas = ConexionDB.GetCargas(idOrden);
            ActualCarga = cargas.Count;
        }

        public static void SetOrder(string order)
        {
            Order = order;
        }

        public static void SetAmount(string amount)
        {
            RequiredAmount = amount;
        }

        public static void SetReqProducts(int reqProductas)
        {
            RequiredProducts = reqProductas;
        }
        public static void ClearOrder()
        {
            Order = string.Empty;
        }
        public static void SumarLigeroSaco()
        {
            if (SacosLigerosNecesarios > 0)
            {
                SacosLigerosCargados++;
                Thread.Sleep(500);
            }
        }
        public static void SumarPesadoSaco()
        {
            if (SacosPesadosNecesarios > 0)
            {
                SacosPesadosCargados++;
                Thread.Sleep(500);
            }
        }

        private static void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            //ReqPeso = ;
            //Validar condiciones previas a la secuencia de pesaje
            if (string.IsNullOrEmpty(Usuario.Nombre))
            {
                InstructionText = "Inicia sesión";
				InstructionLigeros = string.Empty;
				InstructionPesados = string.Empty;
                InstObjetivoLigero = $"";
                InstObjetivoPesado = $"";
                ActualImagen = Resources.BtnConfig600;
                sequenceRunning = false;
                return;
            }
            if (Order == string.Empty || Order == "clear")
            {
                InstructionText = "Escanea una orden";
                ActualImagen = Resources.order;
				InstructionLigeros = string.Empty;
				InstructionPesados = string.Empty;
                InstObjetivoLigero = $"";
                InstObjetivoPesado = $"";
                sequenceRunning = false;
                return;
            }
            if (Status == OrderStatus.Canceled)
            {
                InstructionText = "Orden Cerrada";
                ActualImagen = Resources.ok;
                sequenceRunning = false;
                return;
            }
            if (Status == OrderStatus.Completed)
            {
                InstructionText = "Orden Completada";
                ActualImagen = Resources.ok;
                sequenceRunning = false;
                return;
            }
            if (SelectedProducto.Producto == string.Empty)
            {
                InstructionText = "Selecciona un Producto";
                ActualImagen = Resources.comaflex;
                sequenceRunning = false;
                return;
            }
            if (RequiredAmount == string.Empty)
            {
                InstructionText = "Introduce la cantidad requerida";
                ActualImagen = Resources.comaflex;
                sequenceRunning = false;
                return;
            }
            if (idCarga == 0) return;
            //if (!continueOrder && !cancelOrder && Usuario.Actions.CanCancelOrder())
            //{
            //	InstructionText = "Cancelar orden?";
            //	return;
            //}
            //else
            //	continueOrder = true;

            if (sequenceBusy)
            {
                // Si la secuencia ya está en ejecución, simplemente regresa
                return;
            }

            // Si no, establece la variable de bloqueo como verdadera
            sequenceBusy = true;
            // Ejecutar la secuencia
            WeighingSequence();
            // Al finalizar la ejecución, restablecer la variable de bloqueo
            sequenceBusy = false;
        }
        public static void PesoLigeroOK()
        {
            PesoLigeroOk = true;
        }
        public static void CodigoLigeroOK()
        {
            CodigoLigeroOk = true;
        }
        public static void CodigoPesadoOK()
        {
            CodigoPesadoOk = true;
        }
        public static void PesoPesadoOK()
        {
            PesoPesadoOk = true;
        }
        public static void WeighingSequence()
        {
            sequenceRunning = true;
            //var materialToWeight = Materials?.FirstOrDefault(material => !material.Passed);
            var materialLigeroToWeight = MaterialesLigeros?.FirstOrDefault(material => !material.Passed);
            var materialPesadoToWeight = MaterialesPesados?.FirstOrDefault(material => !material.Passed);

            if (materialLigeroToWeight is null)
            {
                InstObjetivoLigero = $"";
                InstructionLigeros = $"Pesaje terminado";
            }
            if (materialPesadoToWeight is null)
            {
                InstObjetivoPesado = $"";
                InstructionPesados = $"Pesaje terminado";
            }

            //ActualCantidadAPesar = materialToWeight.Cantidad.ToString();
            //ActualMaterialAPesar = materialToWeight;
            if (materialLigeroToWeight is not null)////////////////////////////////////////////////////////////////////////////////////////
            {
                CantidadLigeraAPesar = materialLigeroToWeight.Cantidad.ToString();
                MaterialLigeroAPesar = materialLigeroToWeight;

                if (CodigoLigeroOk == false)
                {
                    //if (!materialToWeight.Escaneable)
                    if (!materialLigeroToWeight.Escaneable)
                        CodigoLigeroOk = true;
                    else
                    {
                        InstObjetivoLigero = $"";
                        InstructionLigeros = $"Escanee{Environment.NewLine}{MaterialLigeroAPesar.Material}{Environment.NewLine} {MaterialLigeroAPesar.Nombre}";
                    }
                }

				if (CodigoLigeroOk)
				{
					if (materialLigeroToWeight.Saco && !SacoLigeroReady)
					{//si se maneja por sacos hacer el calculo solo una vez
						SacosLigerosNecesarios = 0;
						SacosLigerosNecesarios = (int)(materialLigeroToWeight.Cantidad / materialLigeroToWeight.PesoSaco);
						SacoLigeroFraccion = materialLigeroToWeight.Cantidad % materialLigeroToWeight.PesoSaco;
						SacoLigeroFraccion = Math.Round(SacoLigeroFraccion, 3);
						SacosLigerosCargados = 0;
						SacoLigeroReady = true;
					}
					if (materialLigeroToWeight.Saco && SacoLigeroReady)
					{//si se maneja por sacos empezar a pedir cada uno
						if (SacosLigerosCargados < SacosLigerosNecesarios)
                        {//Cargue saco {SacosLigerosCargados + 1}{Environment.NewLine}
                            InstObjetivoLigero = $"Saco {SacosLigerosCargados + 1}";
                            InstructionLigeros = $"{MaterialLigeroAPesar.Material}{Environment.NewLine} {MaterialLigeroAPesar.Nombre}";
						}
						else
						{//carga de sacos completa falta la fraccion
                            if (SacoLigeroFraccion > 0) //-{ SacoLigeroFraccion} kg - {Environment.NewLine}
                            {
                                InstObjetivoLigero = $"{SacoLigeroFraccion} kg";
                                InstructionLigeros = $"{MaterialLigeroAPesar.Material}{Environment.NewLine} {MaterialLigeroAPesar.Nombre}";
                            }
                            else
                                PesoLigeroOk = true;
						}
					}
					if (!materialLigeroToWeight.Saco)
					{
						if (MaterialLigeroAPesar.Nombre is not null)
						{
							if (MaterialLigeroAPesar.esAceite)
							//if (MaterialLigeroAPesar.Nombre.Contains("Chevron") || MaterialLigeroAPesar.Nombre.Contains("chevron"))
							{
								double? litros = 0.0;
								double kilos = 0.0;
								double.TryParse(CantidadLigeraAPesar, out kilos);
								if (UserSettings.Densidad > 0)//-{litros?.ToString("0.###")} Litros-{Environment.NewLine}
                                    litros = kilos / UserSettings.Densidad;

                                InstObjetivoLigero = $"{litros?.ToString("0.###")} L";
                                InstructionLigeros = $"{MaterialLigeroAPesar.Material}{Environment.NewLine} {MaterialLigeroAPesar.Nombre}";
							}
							else
                            {//-{CantidadLigeraAPesar} kg-{Environment.NewLine}
                                InstObjetivoLigero = $"{CantidadLigeraAPesar} kg";
                                InstructionLigeros = $"{MaterialLigeroAPesar.Material}{Environment.NewLine} {MaterialLigeroAPesar.Nombre}";
							}
							SacoLigeroReady = false;
						}
					}
				}

				if (PesoLigeroOk && CodigoLigeroOk)
				{
					Thread.Sleep(200);
					materialLigeroToWeight.Passed = true;
					SacoLigeroFraccion = 0.0;
					SacosLigerosCargados = 0;
					SacosLigerosNecesarios = 0;
					SacoLigeroReady = false;
					PesoLigeroOk = false;
					CodigoLigeroOk = false;
				}
			}
			else
			{
				MaterialLigeroAPesar = null;
				CantidadLigeraAPesar = string.Empty;
			}

			if (materialPesadoToWeight is not null)///////////////////////////////
            {
                CantidadPesadaAPesar = materialPesadoToWeight.Cantidad.ToString();
                MaterialPesadoAPesar = materialPesadoToWeight;

				if (CodigoPesadoOk == false)
				{
                    //if (!materialToWeight.Escaneable)
                    if (!materialPesadoToWeight.Escaneable)
                        CodigoPesadoOk = true;
                    else
                    {
                        InstructionPesados = $"Escanee{Environment.NewLine}{MaterialPesadoAPesar.Material}{Environment.NewLine} {MaterialPesadoAPesar.Nombre}";
                        InstObjetivoPesado = $"";
                    }
				}
				if (CodigoPesadoOk)
				{
					if (materialPesadoToWeight.Saco && !SacoPesadoReady)
					{//si se maneja por sacos hacer el calculo solo una vez
						SacosPesadosNecesarios = 0;
						SacosPesadosNecesarios = (int)(materialPesadoToWeight.Cantidad / materialPesadoToWeight.PesoSaco);
						SacoPesadoFraccion = materialPesadoToWeight.Cantidad % materialPesadoToWeight.PesoSaco;
						SacoPesadoFraccion = Math.Round(SacoPesadoFraccion, 3);
						SacosPesadosCargados = 0;
						SacoPesadoReady = true;
					}
					if (materialPesadoToWeight.Saco && SacoPesadoReady)
					{//si se maneja por sacos empezar a pedir cada uno
						if (SacosPesadosCargados < SacosPesadosNecesarios)
                        {//Cargue saco {SacosPesadosCargados + 1}{Environment.NewLine}
                            InstObjetivoPesado = $"Saco {SacosPesadosCargados + 1}";
                            InstructionPesados = $"{MaterialPesadoAPesar.Material}{Environment.NewLine} {MaterialPesadoAPesar.Nombre}";
						}
						else
						{//carga de sacos completa falta la fraccion
                            if (SacoPesadoFraccion > 0)//-{SacoPesadoFraccion} kg-{Environment.NewLine}
                            {
                                InstObjetivoPesado = $"{SacoPesadoFraccion} kg";
                                InstructionPesados = $"{MaterialPesadoAPesar.Material}{Environment.NewLine} {MaterialPesadoAPesar.Nombre}";
                            }
                            else
                                PesoPesadoOk = true;
						}
					}
					if (!materialPesadoToWeight.Saco)
					{
						if (MaterialPesadoAPesar.Nombre is not null)
						{
							if (MaterialPesadoAPesar.esAceite)
							//if (MaterialPesadoAPesar.Nombre.Contains("Chevron") || MaterialPesadoAPesar.Nombre.Contains("chevron"))
							{
								double? litros = 0.0;
								double kilos = 0.0;
								double.TryParse(CantidadPesadaAPesar, out kilos);
								if (UserSettings.Densidad > 0)
									litros = kilos / UserSettings.Densidad;
                                InstObjetivoPesado = $"{litros?.ToString("0.###")} L";
                                //-{litros?.ToString("0.###")} Litros-{Environment.NewLine}
                                InstructionPesados = $"{MaterialPesadoAPesar.Material}{Environment.NewLine} {MaterialPesadoAPesar.Nombre}";
							}
							else
                            {//-{CantidadPesadaAPesar} kg-{Environment.NewLine}
                                InstObjetivoPesado = $"{CantidadPesadaAPesar} kg";
                                InstructionPesados = $"{MaterialPesadoAPesar.Material}{Environment.NewLine} {MaterialPesadoAPesar.Nombre}";
							}
							SacoPesadoReady = false;
						}
					}
				}

				if (PesoPesadoOk && CodigoPesadoOk)
				{
					Thread.Sleep(200);
					materialPesadoToWeight.Passed = true;
					SacoPesadoFraccion = 0.0;
					SacosPesadosCargados = 0;
					SacosPesadosNecesarios = 0;
					SacoPesadoReady = false;
					PesoPesadoOk = false;
					CodigoPesadoOk = false;
				}
			}
            else
            {
                MaterialPesadoAPesar = null;
                CantidadPesadaAPesar = string.Empty;
            }

            if (materialLigeroToWeight?.Imagen is not null)
                ActualImagen = materialLigeroToWeight.Imagen;
            else if (materialPesadoToWeight?.Imagen is not null)
                    ActualImagen = materialPesadoToWeight.Imagen;
            else
            {
                //ActualImagen = null;
                if ((CodigoLigeroOk == false && CantidadLigeraAPesar != string.Empty) || (CodigoPesadoOk == false && CantidadPesadaAPesar != string.Empty))
                    ActualImagen = Resources.Scaner;
                else
                    ActualImagen = Resources.Bascula;
            }

            //Ambos pesajes terminados
			if (materialPesadoToWeight is null && materialLigeroToWeight is null)
			{
				InstructionText = $"Pesaje terminado";
				//ActualImagen = null;
				ActualImagen = Resources.ok;

				if (!ConexionDB.UpdateCarga(idCarga))
					MessageBox.Show($"error al UpdateCarga {idCarga}");

				ConexionDB.RegisterConsumption(Materials, idOrden);

				if (ActualCarga >= RequiredProducts)//cuando termina todas las cargas
				{
					InstructionText = $"Orden Completada";
					Status = OrderStatus.Completed;
					ConexionDB.UpdateOrderStatus(idOrden, Status);
					//Email email = new(idOrden);
					//email.CreateReport(idOrden);
				}

				Thread.Sleep(1000);

				if (ActualCarga >= RequiredProducts)
				{
					ClearData();
				}

				Usuario.Logout();
				if (Materials is not null)
				{
					foreach (var product in Materials)
					{
						product.Passed = false;
					}
				}

				ShowLogin = true;
				ActualImagen = null;
				return;
			}
			else
			{
				InstructionText = "Siga las indicaciones de cada báscula";
			}
		}
    }
}

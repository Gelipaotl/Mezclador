using Mezclador.Models;
using System.Data;
using static Mezclador.ConexionDB;

namespace Mezclador
{
    public partial class formSetAmount : Form
    {
        public bool completed = false;
        double CantidadDeseada;
        double CantidadPorProducto;
        double CantidadDeProductos;
        CrudType _crudType;
        List<SumaMateriales> sumaMateriales;
        class SumaMateriales
        {
            public string Material { get; set; }
            public string Nombre { get; set; }
            public double CantidadUnitaria { get; set; }
            public string Total { get; set; }
        }
        public formSetAmount(ProductoModel Producto, CrudType crudType)
        {
            _crudType = crudType;
            InitializeComponent();

            btnRegresar.Visible = _crudType == CrudType.Create;

            tBoxProduct.Text = $"{Producto.Producto} {Producto.Nombre}";
            sumaMateriales = ConexionDB.GetInstructionsList(Producto.Producto).Where(c => c.Habilitado)
                .Select(c => new SumaMateriales() { Nombre = c.Nombre, Material = c.Material, CantidadUnitaria = c.Cantidad, Total = (c.Cantidad * 1).ToString("0.000") }).ToList();

            CantidadPorProducto = sumaMateriales.Sum(c => c.CantidadUnitaria);
            numDesiredAmount.Minimum = (decimal)CantidadPorProducto;
            UpdateValues();
            tBoxOrder.Text = ControlOrdenes.Order;
        }
        public bool UpdateValues(bool inversed = false)
        {
            try
            {
                if (inversed)
                {
                    var productosResultantes = CantidadDeProductos > 0 && !double.IsInfinity(CantidadDeProductos)? 
                        (decimal)(CantidadDeProductos * CantidadPorProducto) : 0;
                    if (productosResultantes > numDesiredAmount.Maximum || productosResultantes < numDesiredAmount.Minimum)
                        return false;

                    numDesiredAmount.Value = productosResultantes;
                }
                else
                {
                    double resultado = (double)numDesiredAmount.Value / CantidadPorProducto;
                    //redondear a .000 si es menor a eso
                    resultado = Math.Round(resultado, 3, MidpointRounding.AwayFromZero);
                    CantidadDeProductos = resultado;
                }

                sumaMateriales = sumaMateriales.Select(c => new SumaMateriales() { Nombre = c.Nombre, Material = c.Material, CantidadUnitaria = c.CantidadUnitaria, Total = (c.CantidadUnitaria * (int)CantidadDeProductos).ToString("0.000") }).ToList();

                dgvMateriales.DataSource = sumaMateriales;
                tBoxTotalProduct.Text = $"{CantidadPorProducto.ToString("0.000")} kg";
                tBoxTotalProducts.Text = CantidadDeProductos.ToString("0.000");

                tBoxTotalProducts.ForeColor = CantidadDeProductos % 1 == 0 ? Color.Black : Color.Red;
                btnAccept.Enabled = CantidadDeProductos % 1 == 0;
                return true;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); return false; }

        }

        private void numDesiredAmount_ValueChanged(object sender, EventArgs e)
        {
            UpdateValues();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                var desiredAmount = numDesiredAmount.Value.ToString();
                var requiredProducts = Convert.ToInt32(CantidadDeProductos);
                if (_crudType == CrudType.Create)
                {
                    ControlOrdenes.SetAmount(desiredAmount);
                    ControlOrdenes.SetReqProducts(requiredProducts);
                    ControlOrdenes.CreateOrder();
                }

                else if (_crudType == CrudType.Update)
                {
                    if (requiredProducts < ControlOrdenes.ActualCarga)
                    {
                        MessageBox.Show("No se puede cambiar la cantidad requerida a un valor menor a la cantidad ya producida");
                        return;
                    }
                    //si la cantidad nueva solicitada es la misma que la ya producina no se reabre la orden
                    if ((ControlOrdenes.Status == OrderStatus.Completed || ControlOrdenes.Status == OrderStatus.Canceled) && requiredProducts == ControlOrdenes.ActualCarga)
                    {
                        MessageBox.Show("Para una orden ya cerrada la cantidad requerida debe ser mayor a la cantidad ya producida");
                        return;
                    }
                    var lastStatus = ControlOrdenes.Status;
                    ControlOrdenes.SetAmount(desiredAmount);
                    ControlOrdenes.SetReqProducts(requiredProducts);
                    ControlOrdenes.UpdateOrder(desiredAmount, requiredProducts, OrderStatus.InProcess);

                    if (lastStatus == OrderStatus.Completed || lastStatus == OrderStatus.Canceled)
                        ControlOrdenes.CreateCarga();
                }

                completed = true;
                Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void formSetAmount_Load(object sender, EventArgs e)
        {

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            var tempCantidad = CantidadDeProductos;
            if (CantidadDeProductos % 1 > 0)
                CantidadDeProductos = Math.Ceiling(CantidadDeProductos);
            else
            {
                if (CantidadDeProductos < 5000)
                    CantidadDeProductos++;
            }

            // si el calculo excede el tope de numeric se revierte el incremento
            if (!UpdateValues(inversed: true))
            {
                CantidadDeProductos = tempCantidad;
            }

        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (CantidadDeProductos % 1 > 0)
                CantidadDeProductos = Math.Floor(CantidadDeProductos);
            else
            {
                if (CantidadDeProductos > 1)
                    CantidadDeProductos--;
            }
            UpdateValues(inversed: true);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            ControlOrdenes.SelectedProducto.Producto = string.Empty;
            //formSelectProducto formSelectProducto = new();
            //formSelectProducto.Show();
            Close();
        }

        private void formSetAmount_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void amountUp_Click(object sender, EventArgs e)
        {
            numDesiredAmount.UpButton();
        }

        private void amountDown_Click(object sender, EventArgs e)
        {
            numDesiredAmount.DownButton();
        }

        private void tBoxProduct_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

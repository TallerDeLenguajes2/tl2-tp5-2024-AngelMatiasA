﻿namespace Tp5Tienda.Models
{
    public class Presupuestos
    {
        public int IdPresupuesto { get; set; }
        public string nombreDestinatario { get; set; }
        public List<PresupuestoDetalle> Detalle { get; set; } = new List<PresupuestoDetalle>();

        public double MontoPresupuesto()
        {
            double montoTotal = 0, monto ;
            foreach (var det in Detalle)
            {
                monto = 0;
                monto += Convert.ToDouble(det.Producto.Precio);
                monto = monto * det.Cantidad;
                montoTotal += monto;
            }
            return montoTotal;

        }
        public double MontoPresupuestoConIva()
        {
            double conIva = 0;
            conIva = MontoPresupuesto();
            conIva = conIva * 1.21;
            return conIva;

        }
        public int CantiadProductos()
        {
            int cantidad = 0;
            foreach (var det in Detalle)
            {
                cantidad += det.Cantidad;
                
            }
            return cantidad;

        }
    }
}
namespace Tp5Tienda.Models
{
    public class PresupuestoDetalle
    {
        public int IdPresupuesto { get; set; }
        public Productos Producto { get; set; }
        public int Cantidad { get; set; }
    }
}

using ProyectoServicioTigo.Modelos;

namespace ProyectoServicioTigo.Servicios
{
    public class DecoratorPlan : PackageBase
    {
        private readonly PackageBase _planBase;
        private readonly ServiceExtra _extra;

        public DecoratorPlan(PackageBase planBase, ServiceExtra extra)
        {
            _planBase = planBase;
            _extra = extra;
        }

        // ✔️ Estas son las propiedades que causaban error al faltar
        public PackageBase Plan => _planBase;
        public ServiceExtra Extra => _extra;

        public override string Nombre => $"{_planBase.Nombre} + {_extra.Nombre}";

        public override string Descripcion => $"{_planBase.Descripcion}\nIncluye: {_extra.Nombre}";

        public override decimal CostoBase => _planBase.CostoBase + _extra.Costo;
    }
}

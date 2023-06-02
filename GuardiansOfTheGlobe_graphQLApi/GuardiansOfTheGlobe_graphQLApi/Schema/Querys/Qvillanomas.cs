using GuardiansOfTheGlobe_graphQLApi.Models;
using GuardiansOfTheGlobeApi.Models;

namespace GuardiansOfTheGlobe_graphQLApi.Schema.Querys
{
    [ExtendObjectType("Query")]
    public class Qvillanomas : ObjectType<Villanomas>
    {

        protected override void Configure(IObjectTypeDescriptor<Villanomas> descriptor)
        {
            descriptor.Name("VillanoConPeleas");
            descriptor.Description("Tipo de objeto para representar el resultado del procedimiento almacenado ObtenerVillanoConMasPeleas.");

            descriptor.Field(f => f.NombreVillano)
                .Name("nombre_villano")
                .Type<NonNullType<StringType>>();

            descriptor.Field(f => f.CantidadDePeleas)
                .Name("cantidad_de_peleas")
                .Type<NonNullType<IntType>>();
        }

    }
}

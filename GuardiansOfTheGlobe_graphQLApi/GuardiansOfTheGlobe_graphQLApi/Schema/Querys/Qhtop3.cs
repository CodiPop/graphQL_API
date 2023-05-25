using GuardiansOfTheGlobe_graphQLApi.Models;

namespace GuardiansOfTheGlobe_graphQLApi.Schema.Querys
{

    [ExtendObjectType("Query")]
    public class Qhtop3 : ObjectType<Heroestop3>
    {

        protected override void Configure(IObjectTypeDescriptor<Heroestop3> descriptor)
        {
            descriptor.Name("Heroestop3");
            descriptor.Description("Tipo de objeto para representar los tres héroes con más victorias.");

            descriptor.Field(f => f.Nombre)
                .Type<NonNullType<StringType>>()
                .Name("nombre");

            descriptor.Field(f => f.Victorias)
                .Type<NonNullType<IntType>>()
                .Name("victorias");
        }
    }
}

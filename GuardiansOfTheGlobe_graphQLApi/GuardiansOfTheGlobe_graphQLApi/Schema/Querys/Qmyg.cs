namespace GuardiansOfTheGlobe_graphQLApi.Schema.Querys
{
    using GuardiansOfTheGlobe_graphQLApi.Models;
    using GuardiansOfTheGlobeApi.Models;
    using HotChocolate.Types;
    [ExtendObjectType("Query")]
    public class Qmyg : ObjectType<MyG>
    {
        protected override void Configure(IObjectTypeDescriptor<MyG> descriptor)
        {
            descriptor.Name("MyG");
            descriptor.Description("Tipo de objeto para representar una pelea entre un héroe y un villano.");

            descriptor.Field(f => f.NombreHeroe)
                .Name("nombre_heroe")
                .Type<NonNullType<StringType>>();

            descriptor.Field(f => f.NombreVillano)
                .Name("nombre_villano")
                .Type<NonNullType<StringType>>();

            descriptor.Field(f => f.Resultado)
                .Type<NonNullType<StringType>>();
        }



    }
}

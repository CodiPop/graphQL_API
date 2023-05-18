namespace GuardiansOfTheGlobe_graphQLApi.Schema
{
    public class HeroeType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Habilidades { get; set; } 
        public string Debilidades { get; set; }
        public string RelacionesPersonales { get; set; }
        public int Edad { get; set; }

    }
}

namespace GuardiansOfTheGlobe_graphQLApi.DTOs
{
    public class HeroeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Habilidades { get; set; }
        public string Debilidades { get; set; }
        public string RelacionesPersonales { get; set; }
        public int Edad { get; set; }
    }
}

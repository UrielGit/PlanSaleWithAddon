namespace PlanSaleWithAddon.JWT
{
    public class JWTSettings
    {
        public string? Secret { get; set; }
        public int Expiration { get; set; }
        public string? Author { get; set; }
        public string? Valid { get; set; }

    }
}

namespace USER.WebApi.Domain.Models {
    public class Phone {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Number { get; set; }
        public int AreaCode { get; set; }
        public int CountryCode { get; set; }

        public User User { get; set; }
    }
}
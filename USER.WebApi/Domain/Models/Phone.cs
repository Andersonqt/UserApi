namespace USER.WebApi.Domain.Models {
    public class Phone {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Number { get; set; }
        public int Area_Code { get; set; }
        public string Country_Code { get; set; }
    }
}
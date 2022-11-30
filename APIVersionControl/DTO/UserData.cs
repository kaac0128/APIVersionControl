namespace APIVersionControl.DTO
{
    public class User
    {
        public string? Id { get; set; }
        public string? title { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? picture { get; set; }
    }

    public class UserResponseData
    {
        public User[]? data { get; set; }
        public int total { get; set; }
        public int page { get; set; }
        public int limit { get; set; }

    }
   
}

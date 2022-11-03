using System;
namespace WebApiBoombit.DTOs.RequestDTO
{
    public class UserRequestDTO
    {
        public int id { set; get; }
        public string? name { set; get; }
        public string? last { set; get; }
        public string? email { set; get; }
        public string? birthday { set; get; }
        public string? phone { set; get; }
        public string? country { set; get; }
        public bool information { set; get; }
    }
}


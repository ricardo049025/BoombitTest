using System;
namespace WebApiBoombit.DTOs.ResponseDTO
{
    public class ActivityResponseDTO
    {
        public int id { set; get; }
        public string? fullName { set; get; }
        public string createdDate { set; get; }
        public string? description { set; get; }
    }
}


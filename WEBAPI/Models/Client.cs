using System;
using System.ComponentModel.DataAnnotations;

namespace WEBAPI.Models
{
    public enum ApplicationTypes
    {
        JavaScript = 0,
        NativeConfidential = 1
    }

    public class Client
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Secret { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ApplicationTypes ApplicationType { get; set; }
        public bool Active { get; set; }
        public int RefreshtokenLifetime { get; set; }

        public string AllowedOrigin { get; set; }
    }
}
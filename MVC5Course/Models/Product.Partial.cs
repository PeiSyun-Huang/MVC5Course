namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product : IValidatableObject
    {
        // 自訂模組驗證
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Price <= 2000)
            {
                yield return new ValidationResult("金額必須大於2000", new[] { "Price" });
            }
            if (this.ProductName.Length < 5)
            {
                yield return new ValidationResult("名稱長度需大於5", new[] { "ProductName" });
            }
        }
    }

    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }

        [StringLength(80, ErrorMessage = "欄位長度不得大於 80 個字元")]
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<decimal> Stock { get; set; }

        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}

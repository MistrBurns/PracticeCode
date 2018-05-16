using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;
using static Acme.Common.LoggingService;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products
    /// </summary>
    public class Product
    {
        public const double InchesPerMeter = 39.37;
        public readonly decimal MinimumPrice;
        public Product()
        {
            Console.WriteLine("Product created");
            this.MinimumPrice = .96m;
            this.Category = "Tools";
        }
        public Product(int productId, string productName, string productDescription) : this()
        {
            this.ProductName = productName;
            this.ProductDescription = productDescription;
            this.ProductId = productId;
            if (ProductName.StartsWith("Bulk"))
                this.MinimumPrice = 9.99m;
        }
        private string  productName;

        public string  ProductName
        {
            get {
                var formattedValue = productName?.Trim();
                return formattedValue;
            }
            set {
                if (value.Length < 3 || value.Length > 20)
                    ValidationMessage = "Name must be 3-20 chars long";
                else
                    productName = value;
            }
        }

        private string productDescription;

        public string ProductDescription
        {
            get { return productDescription; }
            set { productDescription = value; }
        }
        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
        private DateTime? availabilityDate;

        public DateTime? AvailabilityDate
        {
            get { return availabilityDate; }
            set { availabilityDate = value; }
        }

        private Vendor productVendor;

        public Vendor ProductVendor
        {
            get
            {
                if (productVendor == null)
                    productVendor = new Vendor();
                return productVendor;
            }
            set { productVendor = value; }
        }

        public string ProuctCode => $"{this.Category}_{this.SequenceNumber:0000}";
        public decimal Cost { get; set; }
        #region auto_implemented_properties
        internal string Category {  get; set; } //default value in constructor
        public int SequenceNumber { get; set; } = 1; //default value on assignment
        public string ValidationMessage { get; private set; }
        #endregion

        public string SayHello()
        {
            // only good, when only needed in this method
            //var vendor = new Vendor();
            //vendor.SendWelcomeEmail("Message from Product");

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Product",
                this.ProductName, "sales@abc.com");
            var result = LogAction("Email sent");
            return "Hello " + ProductName + " " + ProductDescription + " " + ProductId
                + " Available on: " + AvailabilityDate?.ToShortDateString();
        }

        public override string ToString()
        {
            return this.productName + " (" + this.productId + ")";
            
        }

        public decimal CalculateSuggestedPrice(decimal markupPercent) => this.Cost + (this.Cost * markupPercent / 100);

    }
}

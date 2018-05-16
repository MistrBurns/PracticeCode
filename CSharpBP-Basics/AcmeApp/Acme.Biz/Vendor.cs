using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages the vendors from whom we purchase our inventory.
    /// </summary>
    public class Vendor
    {
        public enum IncludeAdress { yes, no };
        public enum SendCopy { yes, no };

        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Sends an email to welcome a new vendor.
        /// </summary>
        /// <returns></returns>
        public string SendWelcomeEmail(string message)
        {
            var emailService = new EmailService();
            var subject = "Hello " + this.CompanyName;
            var confirmation = emailService.SendMessage(subject,
                                                        message,
                                                        this.Email);
            return confirmation;
        }

        public OperationResult PlaceOrder(Product product, int quanity, DateTimeOffset? deliveryBy = null, string instructions = "standard delivery")
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (quanity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quanity));
            if (deliveryBy <= DateTimeOffset.Now)
                throw new ArgumentOutOfRangeException();

            var success = false;
            var emailService = new EmailService();
            
           var orderTextBuilder = new StringBuilder("Order from ABC" + System.Environment.NewLine + "Product:" + product.ProuctCode
                + System.Environment.NewLine + "Quantity: " + quanity);
            if (deliveryBy.HasValue)
                orderTextBuilder.Append(System.Environment.NewLine + "Deliver By: " + deliveryBy.Value.ToString("d"));
            if (!string.IsNullOrWhiteSpace(instructions))
                orderTextBuilder.Append(System.Environment.NewLine + "Instruction: " + instructions);

            string orderText = orderTextBuilder.ToString();
            var confirmation = emailService.SendMessage("New Order", orderText, this.Email);

            if (confirmation.StartsWith("Message sent:"))
                success = true;
            OperationResult result = new OperationResult(success, orderText);
            return result;
        }

        /// <summary>
        /// Places an order to the vendor
        /// </summary>
        /// <param name="prodcut"></param>
        /// <param name="quantity"></param>
        /// <param name="includeAdress"></param>
        /// <param name="sendCopy"></param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product prodcut, int quantity, IncludeAdress includeAdress, SendCopy sendCopy)
        {
            var orderText = "Test";
            if (includeAdress == IncludeAdress.yes)
                orderText += " with adress";
            if (sendCopy == SendCopy.yes)
                orderText += " with copy";

            var operationResult = new OperationResult(true, orderText);
            return operationResult;
        }

        public override string ToString()
        {
            string vendorInfo = "Vendor: " + this.CompanyName;
            return vendorInfo;
        }

        public string PreprareDirections()
        {
            var directions = @"Insert \r\n to insert a new line";
            return directions;
        }

        public string PrepareDirectionsTwoLines()
        {
            var directions = "First" + Environment.NewLine + "Second";
            //also possible
            var directions3 = @"First
Second";
            return directions;
        }
    }
        
}

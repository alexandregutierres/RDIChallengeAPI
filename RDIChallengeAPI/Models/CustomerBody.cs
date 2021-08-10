using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace RDIChallengeAPI.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class CustomerBody : IEquatable<CustomerBody>
    {
        /// <summary>
        /// Gets or Sets CustomerId
        /// </summary>
        [Required]
        [DataMember(Name = "CustomerId")]
        public int? CustomerId { get; set; }

        /// <summary>
        /// Gets or Sets CardNumber
        /// </summary>
        [Required]
        [DataMember(Name = "CardNumber")]
        public long? CardNumber { get; set; }

        /// <summary>
        /// Gets or Sets CVV
        /// </summary>
        [Required]
        [DataMember(Name = "CVV")]
        public int? CVV { get; set; }

        /// <sumary>
        /// Gets or Sets Registration Date
        /// </sumary>
        [DataMember(Name = "RegistrationDate")]
        public DateTime RegistrationDate { get; set; }

        /// <sumary>
        /// Gets or Sets Token
        /// </sumary>
        [DataMember(Name = "Token")]
        public long? Token { get; set; }

        /// <sumary>
        /// Gets or Sets CardId
        /// </sumary>
        [DataMember(Name = "CardId")]
        public int? CardId { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CustomersBody {\n");
            sb.Append("  CustomerId: ").Append(CustomerId).Append("\n");
            sb.Append("  CardNumber: ").Append(CardNumber).Append("\n");
            sb.Append("  CVV: ").Append(CVV).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((CustomerBody)obj);
        }

        /// <summary>
        /// Returns true if CustomersBody instances are equal
        /// </summary>
        /// <param name="other">Instance of CustomersBody to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CustomerBody other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    CustomerId == other.CustomerId ||
                    CustomerId != null &&
                    CustomerId.Equals(other.CustomerId)
                ) &&
                (
                    CardNumber == other.CardNumber ||
                    CardNumber != null &&
                    CardNumber.Equals(other.CardNumber)
                ) &&
                (
                    CVV == other.CVV ||
                    CVV != null &&
                    CVV.Equals(other.CVV)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (CustomerId != null)
                    hashCode = hashCode * 59 + CustomerId.GetHashCode();
                if (CardNumber != null)
                    hashCode = hashCode * 59 + CardNumber.GetHashCode();
                if (CVV != null)
                    hashCode = hashCode * 59 + CVV.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(CustomerBody left, CustomerBody right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CustomerBody left, CustomerBody right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }

    public class CustomerApi
    { 
        /// <sumary>
        /// Gets or Sets Registration Date
        /// </sumary>
        [DataMember(Name = "RegistrationDate")]
        public DateTime RegistrationDate { get; set; }

        /// <sumary>
        /// Gets or Sets Token
        /// </sumary>
        [DataMember(Name = "Token")]
        public long? Token { get; set; }

        /// <sumary>
        /// Gets or Sets CardId
        /// </sumary>
        [DataMember(Name = "CardId")]
        public int? CardId { get; set; }
    }

    public class CustomerValidate
    { 
        /// <summary>
        /// Gets or Sets CustomerId
        /// </summary>
        [Required]
        [DataMember(Name = "CustomerId")]
        public int? CustomerId { get; set; }

        /// <summary>
        /// Gets or Sets CVV
        /// </summary>
        [Required]
        [DataMember(Name = "CVV")]
        public int? CVV { get; set; }

        /// <sumary>
        /// Gets or Sets Token
        /// </sumary>
        [Required]
        [DataMember(Name = "Token")]
        public long? Token { get; set; }

        /// <sumary>
        /// Gets or Sets CardId
        /// </sumary>
        [Required]
        [DataMember(Name = "CardId")]
        public int? CardId { get; set; }
    }
}

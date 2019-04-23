using System;
using System.Globalization;
using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Accounting {
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class Money : SingleValueObject<decimal> {
        public Money (decimal value) : base (value) {
            if (value < 0) throw new ArgumentException (nameof (value));
        }

        public static Money operator + (Money m1, Money m2) {
            return new Money (m1.Value + m2.Value);
        }

        public static Money operator - (Money m1, Money m2) {
            return new Money (m1.Value - m2.Value);
        }

        public override string ToString () {
            return Value.ToString (CultureInfo.InvariantCulture);
        }
    }
}
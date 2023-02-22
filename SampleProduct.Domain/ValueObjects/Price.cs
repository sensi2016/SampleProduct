namespace SampleProduct.Domain.ValueObjects;

public class Price : ValueObject
{
    public Price(decimal value)
    {
        if(value< 0) throw new ArgumentOutOfRangeException();

        this.Value=value;
    }


    public decimal Value { get; init; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static Price operator +(Price p1, Price p2)
    {
        return new Price(p1.Value + p2.Value);
    }
}

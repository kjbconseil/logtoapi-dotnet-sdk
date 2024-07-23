namespace Logto.WebApi.Sdk.Common;

internal record Token
{
    private readonly DateTimeOffset _expiredAt = DateTimeOffset.Now;

    public string Value { get; private set; }

    public bool IsExpired => DateTimeOffset.Now >= _expiredAt;

    public Token(string value, int expiresIn)
    {
        Value = value;
        _expiredAt = DateTimeOffset.Now.AddSeconds(expiresIn);
    }
}

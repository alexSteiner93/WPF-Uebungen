namespace AutoUi.Util
{
    public interface IBindableWindow<TVm>
        where TVm: new()
    {
        TVm Model { get; set; }
    }
}

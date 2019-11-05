namespace Assignment1.Mvvm.Core
{
    /// <summary>
    /// Dies ist eine normale POCO (plain old C# object) Klasse.
    /// Wenn wir zur Laufzeit Properties ändern, merkt das UI
    /// nichts davon
    /// </summary>
    public class GreetingVm
    {
        public string Name { get; set; }

        public string Greeting { get; set; }
    }
}

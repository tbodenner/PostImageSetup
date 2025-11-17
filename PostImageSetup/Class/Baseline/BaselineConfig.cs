namespace PostImageSetup.Class.Baseline
{
  internal class BaselineConfig
  {
    public BaselineConfig(Dictionary<string, string[]>? inputDict)
    {
      BaselineDictionary = inputDict;
    }
    public Dictionary<string,string[]>? BaselineDictionary { get; set; }
  }
}

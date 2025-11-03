namespace Ingestion.Pipeline.Importers
{
    /// <summary>
    /// Abstract Generic class <br></br>
    /// T : Type of object to be imported <br></br>
    /// List Import(string filePath) <br></br>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FileImporter<T>
    {
        public abstract List<T> Import(string filePath);
    }
}

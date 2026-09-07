using System;

public class SqlFile
{
   public string FilePath {get;set;}
   public string FileText {get;set;}
   public string LoadText()
   {

   }
   public string SaveText()
   {

   }
}
public class SqlFileManager
{
   public List<SqlFile> lstSqlFiles {get;set}

   public string GetTextFromFiles()
   {
      StringBuilder objStrBuilder = new StringBuilder();
      foreach(var objFile in lstSqlFiles)
      {
         objStrBuilder.Append(objFile.LoadText());
      }
      return objStrBuilder.ToString();
   }
   public void SaveTextIntoFiles()
   {
      foreach(var objFile in lstSqlFiles)
      {
         objFile.SaveText();
      }
   }
}

    public class SqlFile
{
   public string LoadText()
   {

   }
   public void SaveText()
   {

   }
}
public class ReadOnlySqlFile: SqlFile
{
   public string FilePath {get;set;}
   public string FileText {get;set;}
   public string LoadText()
   {

   }
   public void SaveText()
   {

      throw new IOException("Can't Save");
   }
}

    public class SqlFileManager
{
   public List<SqlFile? lstSqlFiles {get;set}
   public string GetTextFromFiles()
   {
      StringBuilder objStrBuilder = new StringBuilder();
      foreach(var objFile in lstSqlFiles)
      {
         objStrBuilder.Append(objFile.LoadText());
      }
      return objStrBuilder.ToString();
   }
   public void SaveTextIntoFiles()
   {
      foreach(var objFile in lstSqlFiles)
      {


         if(! objFile is ReadOnlySqlFile)
         objFile.SaveText();
      }
   }
}

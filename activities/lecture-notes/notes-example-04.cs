using System;

public Interface ILead
{
   void CreateSubTask();
   void AssginTask();
   void WorkOnTask();
}
public class TeamLead : ILead
{
   public void AssignTask()
   {

   }
   public void CreateSubTask()
   {

   }
   public void WorkOnTask()
   {

   }
}

public class Manager: ILead
{
   public void AssignTask()
   {

   }
   public void CreateSubTask()
   {

   }
   public void WorkOnTask()
   {
      throw new Exception("Manager can't work on Task");
   }
}

public interface IProgrammer
{
   void WorkOnTask();
}
public interface ILead
{
   void AssignTask();
   void CreateSubTask();
}
public class Programmer: IProgrammer
{
   public void WorkOnTask()
   {

   }
}
public class Manager: ILead
{
   public void AssignTask()
   {

   }
   public void CreateSubTask()
   {

   }
}

public class TeamLead: IProgrammer, ILead
{
   public void AssignTask()
   {

   }
   public void CreateSubTask()
   {

   }
   public void WorkOnTask()
   {

   }
}

Greetings greetings = new Greetings();
do
{
    
  greetings.GetName();
} while (string.IsNullOrEmpty(greetings.name));
do
{
   greetings.getYOB(greetings.name);
} while (greetings.YOB == 0);

greetings.getAge(greetings.YOB);

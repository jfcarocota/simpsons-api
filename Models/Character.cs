namespace todoapi.Models
{
    public class Character
    {
        string name;
        string gender;
        int age;
        string description;

        public Character(string name, string gender, int age, string description)
        {
            this.name = name;
            this.gender = gender;
            this.age = age;
            this.description = description;
        }

        public Character(){}

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Gender
        {
            get => gender;
            set => gender = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }
    }
}
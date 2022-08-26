
namespace Quest
{
    public class Hat
    {
        public int ShininessLevel { get; set; }

        public string ShininessDescription()
        {

            if (ShininessLevel <= 2)
            {
                return "dull";
            }
            else if (ShininessLevel <= 5)
            {
                return "noticeable";
            }
            else if (ShininessLevel <= 9)
            {
                return "bright";
            }
            else
            {
                return "blinding";
            }
        }
    }
}
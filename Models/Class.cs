namespace Models
{
    public class Class
{
    public enum ClassNameEnum { Warrior, Mage }
    public ClassNameEnum ClassName { get; set; }
    public HeroAttribute LevelAttributes { get; set; }
    public Class(ClassNameEnum classNameEnum, HeroAttribute levelAttributes)
    {
        ClassName = classNameEnum;
        LevelAttributes = levelAttributes;
    }
}
}
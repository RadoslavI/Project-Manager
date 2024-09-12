namespace ProjectManager.Core.Constants
{
    public static class ValidationRegex
    {
        public const string PropertyRegex = @"^[^<>'""\[\]*^(){}!~#%&]+$";
        public const string DescriptionAndMessageRegex = @"^[^<>]+$";
    }
}

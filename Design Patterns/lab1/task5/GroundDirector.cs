namespace Task5
{
    public class GroundDirector
    {
        public Ground Construct(IGroundBuilder builder)
        {
            builder.BuildAudience();
            builder.BuildGallery();
            builder.BuildSurface();

            return builder.GetGround();
        }
    }
}
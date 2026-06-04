namespace E_Learning.BLL
{
    public class MappingConfigurations : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //if there is prop in response is not the same name in model use this way
            // var config = new TypeAdapterConfig();

            /*config.NewConfig<RegisterRequest, ApplicationUser>()
              .Map(dest => dest.UserName, src => src.Email);*/


        }
    }
}

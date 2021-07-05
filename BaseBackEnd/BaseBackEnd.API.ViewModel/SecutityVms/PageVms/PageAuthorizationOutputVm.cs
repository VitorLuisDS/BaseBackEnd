namespace BaseBackEnd.API.ViewModel.SecutityVms.PageVms
{
    public class PageAuthorizationOutputVm
    {
        public string ModuleCode { get; set; }
        public string PageCode { get; set; }
        public string[] AllowedFunctionalities { get; set; }
    }
}

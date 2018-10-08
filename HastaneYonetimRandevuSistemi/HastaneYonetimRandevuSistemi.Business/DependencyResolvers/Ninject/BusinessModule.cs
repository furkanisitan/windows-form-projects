using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.Concrete.Managers;
using HastaneYonetimRandevuSistemi.DataAccess.Abstract;
using HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework;
using HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework.Configuration;
using Ninject.Modules;
using System.Data.Entity;

namespace HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject
{
    class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAnnouncementService>().To<AnnouncementManager>().InSingletonScope();
            Bind<IAnnouncementDal>().To<EfAnnouncementDal>().InSingletonScope();

            Bind<IAppointmentService>().To<AppointmentManager>().InSingletonScope();
            Bind<IAppointmentDal>().To<EfAppointmentDal>().InSingletonScope();

            Bind<IBranchService>().To<BranchManager>().InSingletonScope();
            Bind<IBranchDal>().To<EfBranchDal>().InSingletonScope();

            Bind<IDoctorService>().To<DoctorManager>().InSingletonScope();
            Bind<IDoctorDal>().To<EfDoctorDal>().InSingletonScope();

            Bind<IPatientService>().To<PatientManager>().InSingletonScope();
            Bind<IPatientDal>().To<EfPatientDal>().InSingletonScope();

            Bind<ISecretaryService>().To<SecretaryManager>().InSingletonScope();
            Bind<ISecretaryDal>().To<EfSecretaryDal>().InSingletonScope();

            Bind<DbContext>().To<DatabaseContext>();
        }
    }
}

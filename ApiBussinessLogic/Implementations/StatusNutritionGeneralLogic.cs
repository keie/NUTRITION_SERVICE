using System.Collections.Generic;
using ApiBussinessLogic.Interfaces;
using ApiModel;
using ApiUnitWork;

namespace ApiBussinessLogic.Implementations
{
    public class StatusNutritionGeneralLogic:IStatusNutritionGeneralLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public StatusNutritionGeneralLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<StatusNutritionGeneral> GetList()
        {
            var statusNutritionGeneralList = _unitOfWork.ISnutrition.GetList();
            List<StatusNutritionGeneral> listCharged = new List<StatusNutritionGeneral>();
            foreach (var registerx in statusNutritionGeneralList)
            {
                var sizeValList = _unitOfWork.ISizeValue.GetList();
                List<SizeValue> listSizes=new List<SizeValue>();
                var kgValList = _unitOfWork.IKgValue.GetList();
                List<KgValue> listKgs=new List<KgValue>();
                var pReferenceList = _unitOfWork.IPersonalReference.GetList();
                List<PersonalReference> listpReferences=new List<PersonalReference>();
                var gradeList = _unitOfWork.IGrade.GetList();
                List<Grade> listGrades = new List<Grade>();
                foreach (var registery in sizeValList)
                {
                    if(registery.id==registerx.idSizeVal){listSizes.Add(_unitOfWork.ISizeValue.GetById(registery.id));}
                }
                foreach (var registerz in kgValList)
                {
                    if(registerz.id==registerx.idKgVal){listKgs.Add(_unitOfWork.IKgValue.GetById(registerz.id));}
                }
                foreach (var registera in pReferenceList)
                {
                    if(registera.id==registerx.idPreference){listpReferences.Add(_unitOfWork.IPersonalReference.GetById(registera.id));}
                }

                foreach (var registerb in gradeList)
                {
                    if(registerb.id==registerx.idGrade){listGrades.Add(_unitOfWork.IGrade.GetById(registerb.id));}
                }
                registerx.sizeValues = listSizes;
                registerx.kgValues = listKgs;
                registerx.pReferences = listpReferences;
                registerx.grades = listGrades;
                listCharged.Add(registerx);
            }
            return (listCharged);
        }

       /* public int ValidateInsertValues(int idPreference, int idGrade, int idSizeValue, int idKgValue)
        {
            return (_unitOfWork.ISnutrition.ValidateInsertValues(idPreference, idGrade, idSizeValue, idKgValue));
        }*/
       public int Insert(StatusNutritionGeneral obj)
       {
           return (_unitOfWork.ISnutrition.Insert(obj));
       }

       public StatusNutritionGeneral GetById(int id)
       {
           return (_unitOfWork.ISnutrition.GetById(id));
       }

       public int DeleteStatusNutritionGeneral(int id)
       {
           return (_unitOfWork.ISnutrition.DeleteStatusNutritionGeneral(id));
       }
    }
}
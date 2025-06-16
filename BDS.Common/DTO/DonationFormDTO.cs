using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Common.DTO
{
    public class DonationFormDTO
    {
        public int UserId { get; set; }
        public int RequestId { get; set; }

        public bool EverDonated { get; set; }
        public bool ChronicDisease { get; set; }
        public bool TreatedLast12Months { get; set; }
        public bool SymptomsLast6Months { get; set; }
        public bool BloodTransfusion { get; set; }
        public bool DentalTreatment { get; set; }
        public bool MinorSurgery { get; set; }
        public bool TattoosOrPiercings { get; set; }
        public bool HivRiskContact { get; set; }
        public bool SexualContact { get; set; }
        public bool InfectionLast6Months { get; set; }
        public bool VaccinatedRecently { get; set; }
        public bool TravelToEpidemicArea { get; set; }
        public bool FluSymptoms { get; set; }
        public bool TakingMedication { get; set; }
        public bool PregnantOrBreastfeeding { get; set; }
        public bool Menstruation { get; set; }
        public bool HivTestConsent { get; set; }

        public string? ReasonForPostpone { get; set; }
        public string? InfoProvider { get; set; }
        public bool AgreedToTerms { get; set; }

        public DateTime FormDate { get; set; }

    }
}

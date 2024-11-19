using HelpingHands.Models;

namespace HelpingHands.Services
{
    public class ProgrammeService
    {
        private List<Programme> _programmes;

        public ProgrammeService(List<Programme> programs)
        {
            _programmes = programs;
        }

        public List<Programme> GetAvailablePrograms()
        {
            return _programmes;
        }

        public void EnrollBeneficiaryInProgram(int beneficiaryId, int programId)
        {
            var programme = _programmes.FirstOrDefault(p => p.ProgrammeID == programId);
            if (programme != null)
            {
                // Logic for enrolling a beneficiary (if applicable)
            }
        }

        public int GetProgramCount()
        {
            return _programmes.Count;
        }

        public void AddSampleData()
        {
            if (!_programmes.Any())
            {
                _programmes.Add(new Programme { ProgrammeID = 1, ProgrammeName = "Winter Clothing Drive", Description = "Provide winter clothing to those in need." });
                _programmes.Add(new Programme { ProgrammeID = 2, ProgrammeName = "Food Distribution", Description = "Distribute food to underserved communities." });
            }
        }
    }

}

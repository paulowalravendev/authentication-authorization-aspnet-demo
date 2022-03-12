using System.Threading.Tasks;
using ConfArch.Data.Models;
using ConfArch.Data.Repositories;
using ConfArch.Data.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConfArch.Web.Controllers
{
    public class ProposalController : Controller
    {
        private readonly IConferenceRepository _conferenceRepo;
        private readonly IProposalRepository _proposalRepo;

        public ProposalController(IConferenceRepository conferenceRepo, IProposalRepository proposalRepo)
        {
            _conferenceRepo = conferenceRepo;
            _proposalRepo = proposalRepo;
        }

        public async Task<IActionResult> Index(int conferenceId)
        {
            var conference = await _conferenceRepo.GetById(conferenceId);
            ViewBag.Title = $"Speaker - Proposals For Conference {conference?.Name} {conference?.Location}";
            ViewBag.ConferenceId = conferenceId;

            return View(await _proposalRepo.GetAllForConference(conferenceId));
        }

        public IActionResult AddProposal(int conferenceId)
        {
            ViewBag.Title = "Speaker - Add Proposal";
            return View(new ProposalModel(conferenceId));
        }

        [HttpPost]
        public async Task<IActionResult> AddProposal(ProposalModel proposal)
        {
            if (ModelState.IsValid)
                await _proposalRepo.Add(proposal);
            return RedirectToAction("Index", new { conferenceId = proposal.ConferenceId });
        }

        public async Task<IActionResult> Approve(int proposalId)
        {
            var proposal = await _proposalRepo.Approve(proposalId);
            return RedirectToAction("Index", new { conferenceId = proposal.ConferenceId });
        }
    }
}

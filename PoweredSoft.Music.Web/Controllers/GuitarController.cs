﻿using Microsoft.AspNetCore.Mvc;
using PoweredSoft.Music.String;
using PoweredSoft.Music.String.Core;
using PoweredSoft.Music.String.Core.Guitar;
using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoweredSoft.Music.Web.Controllers
{
    [ApiController]
    public class GuitarController
    {
        [HttpGet, Route("api/[controller]/StandardTuning")]
        public IGuitar StandardTuning([FromServices]IGuitarService s) => s.StandardTuning();

        [HttpGet, Route("api/[controller]/StandardTuning/{fretCount}")]
        public IGuitar StandardTunning([FromServices]IGuitarService s, int fretCount) => s.StandardTuning(fretCount);

        [HttpGet, Route("api/[controller]/Custom/{fretCount}/{notes}")]
        public IGuitar Custom([FromServices]IStringInstrumentService flus,
            [FromServices]INoteService noteService, int fretCount, string notes)
        {
            var splittedNotes = notes.Split(',');
            var openStrings = splittedNotes.Select(n => noteService.GetNoteByName(n)).ToArray();
            var guitar = flus.CreateInstrument<Guitar>(fretCount, openStrings);
            return guitar;
        }
    }
}

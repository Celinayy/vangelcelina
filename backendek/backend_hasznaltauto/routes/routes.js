const express = require("express");
const Kategoria = require("../models/Kategoria");
const Hirdetes = require("../models/Hirdetes");

const router = express.Router();

// Új hírdetés létrehozása
router.post("/hahu", async (req, res) => {
  const ujHirdetes = new Hirdetes(req.body);
  try {
    if (req.body.arFt % 1000 != 0) {
      res.status(400).json({ error: "arFt: Az ár nem osztható 1000-el!" });
    }
    const ujHirdetesMentes = await ujHirdetes.save();
    res.status(200).json({ message: "A rekord rögzítése sikeres!" });
  } catch (error) {
    res.status(400).json({ message: error.message });
  }
});

// Rendezéses minden hírdetés lekérése
router.get("/hahu/:mezo", async (req, res) => {
  try {
    const data = await Hirdetes.find()
      .sort(req.params.mezo)
      .populate("kategoria", "-_id");
    res.status(200).json(data);
  } catch (error) {
    res.status(500).json({ message: error.message });
  }
});

// ID alapján 1 hírdetés lekérése
router.get("/hahu/getbyid/:id", async (req, res) => {
  try {
    const data = await Hirdetes.findById(req.params.id).populate(
      "kategoria",
      "-_id"
    );
    if (data.length !== 0) {
      res.status(200).json(data);
    } else {
      res.status(404).json({
        message:
          "Nincs olyan hírdetés az adatbázisban, ami ezen azonosítóval rendelkezik!",
      });
    }
  } catch (error) {
    res.status(500).json({ message: error.message });
  }
});

// Adatok frissítése id alapján (id-t ne küldjed el tesztnél, mert hibára fut)
router.patch("/hahu/:id", async (req, res) => {
  try {
    const id = req.params.id;
    const updatedData = req.body;
    const options = { new: true, runValidators: true };
    // hogy a frissítés utáni dokumentumot kapjuk vissza
    const result = await Hirdetes.findByIdAndUpdate(id, updatedData, options);
    if (result) {
      res.status(200).send(result);
    } else {
      res
        .status(400)
        .json({ message: `${id} azonosítóval nem létezik hírdetés!` });
    }
  } catch (error) {
    res.status(400).json({ message: error.message });
  }
});

// Hírdetés törlése ID alapján
router.delete("/hahu/:id", async (req, res) => {
  try {
    const id = req.params.id;
    const data = await Hirdetes.findByIdAndDelete(id);
    if (data) {
      res
        .status(200)
        .json({ message: `A hírdetés ${id} azonosítóval törölve` });
    } else {
        res
        .status(404)
        .json({ message: `A hírdetés ${id} azonosítóval nem létezik!` });
    }
  } catch (error) {
    res
      .status(400)
      .json({ message: error.message });
  }
});

module.exports = router;

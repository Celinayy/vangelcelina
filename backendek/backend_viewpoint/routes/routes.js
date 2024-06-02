const express = require("express");
const Location = require("../models/Location");
const Viewpoint = require("../models/Viewpoint");

const router = express.Router();

// Új Viewpoint felvétele
router.post("/viewpoint", async (req, res) => {
  const newViewpoint = new Viewpoint(req.body);
  try {
    const newViewpointSave = await newViewpoint.save();
    res.status(201).json({ _id: newViewpointSave._id });
  } catch (error) {
    res.status(400).json({ message: error.message });
  }
});

// Összes viewpoint lekérése a locationnal bővítve
router.get("/viewpoints", async (req, res) => {
  try {
    const data = await Viewpoint.find().populate("location", "-_id");
    res.status(200).json(data);
  } catch (error) {
    res.status(500).json({ message: error.message });
  }
});


// Összes Location lekérése önmagukban
router.get("/locations", async (req, res) => {
  try {
    const data = await Location.find();
    res.json(data);
  } catch (error) {
    res.status(500).json({ message: error.message });
  }
});

// LocationName alapján viewpoints listázása
router.get("/locations/:locationName/viewpoints", async (req, res) => {
  try {
    // egy locationt megkeresünk
    const location = await Location.findOne({ locationName: req.params.locationName });

    const viewpoints = await Viewpoint.find({ location: location._id })
    if (viewpoints.length !== 0) {
      res.status(200).json(viewpoints);
    } else {
      res
        .status(404)
        .json({ message: "Ebben a hegységben nem találtam kilátót." });
    }
  } catch (error) {
    res.status(500).json({ message: error.message });
  }
});

// Frissítés ID alapján (PATCH, PUT)
router.patch("/viewpoints/:id", async (req, res) => {
  try {
    const id = req.params.id;
    const updatedData = req.body;
    const options = { new: true, runValidators: true };
    const result = await Viewpoint.findByIdAndUpdate(id, updatedData, options);
    if (result) {
      res.status(200).send(result);
    } else {
      res
        .status(400)
        .json({ message: `${id} azonosítóval nem létezik kilátó!` });
    }
  } catch (error) {
    res.status(400).json({ message: error.message });
  }
});

// Törlés ID alapján
router.delete("/viewpoints/delete/:id", async (req, res) => {
  try {
    const id = req.params.id;
    const data = await Viewpoint.findByIdAndDelete(id);
    res.status(200).send(`A ${data.locationName} nevű "viewpoint" törölve lett.`);
  } catch (error) {
    res.status(400).json({ message: error.message });
  }
});

module.exports = router;

const express = require('express');
const Ingatlan = require('../models/Ingatlan');
const Kategoria = require('../models/Kategoria');

const router = express.Router()

// Új ingatlan léterhozása
router.post('/ingatlan', async (req, res) => {
    const ujIngatlan = new Ingatlan(req.body)
    try{
        const ujIngatlanMentes = await ujIngatlan.save();
        res.status(201).json({"_id": ujIngatlanMentes._id})
    }
    catch(error){
        res.status(400).json({message: "Hiányos adatok!"})
    }
})

// MINDENT LISTÁZ
router.get('/ingatlan', async (req, res) => {
    try{
        const data = await Ingatlan.find().populate('kategoria', '-_id');
        res.status(200).json(data).send()
    }
    catch(error){
        res.status(500).json({message: error.message})
    }
})


// ID ALAPJÁN LEKÉRÉS
router.get('/ingatlan/:id', async (req, res) => {
    try{
        const data = await Ingatlan.findById(req.params.id).populate("kategoria", "-_id")
        if (data) {
            res.status(200).json(data)
        } else {
            res.status(404).json({message: 'Nincs ilyen azonosítójú ingatlan az adatbázisban!'})
        }
    }
    catch(error){
        res.status(500).json({message: error.message})
    }
})

// FRISSÍTÉS ID ALAPJÁN
router.patch('/ingatlan/:id', async (req, res) => {
    try {
        const id = req.params.id;
        const updatedData = req.body;
        const options = { new: true, runValidators: true }; 
        // hogy a frissítés utáni dokumentumot kapjuk vissza
        const result = await Ingatlan.findByIdAndUpdate(
            id, updatedData, options
        )
        if (result) {
            res.status(200).send(result)
        } else {
            res.status(400).json({ message: `${id} azonosítóval nem létezik ingatlan!`  })
        }
    }
    catch (error) {
        res.status(400).json({ message: error.message })
    }
})

// TÖRLÉS ID ALAPJÁN 
router.delete('/ingatlan/:id', async (req, res) => {
    try {
        const id = req.params.id;
        const data = await Ingatlan.findByIdAndDelete(id)
        res.status(204).send()
    }
    catch (error) {
        res.status(404).json({ message: "Az ingatlan nem létezik!" })
    }
})

module.exports = router;
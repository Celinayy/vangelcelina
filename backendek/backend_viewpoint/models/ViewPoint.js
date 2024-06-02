const mongoose = require("mongoose");

const viewpointSchema = new mongoose.Schema({
  _id: {
    type: Number,
    required: true,
  },
  viewpointName: {
    type: String,
    required: true,
    unique: true,
    maxlength: [50, 'A "viewpointName" nem lehet hosszabb 50 karakternél!'],
  },
  mountain: {
    type: String,
    required: true,
    unique: true,
    maxlength: [30, 'A "mountain" nem lehet hosszabb 30 karakternél!'],
  },
  height: {
    type: Number,
    min: [1, "Egy kilátónak legalább 1 méter magasnak kell lennie!"],
  },
  description: {
    type: String,
    required: true,
  },
  built: {
    type: Date,
    max: [
      () => {
        return Date.now();
      },
      "Az aktuális dátumnál nem adhat meg későbbi dátumot a built mezőben!",
    ],
  },
  imageUrl: {
    type: String,
    required: true,
    maxlength: [50, 'A "imageUrl" nem lehet hosszabb 50 karakternél!'],
    default: "http://elit.jedlik.eu/viewpoints/no-img.jpg",
  },
  location: {
    type: Number,
    required: true,
    ref: "Location",
  },
});

module.exports = mongoose.model("Viewpoint", viewpointSchema, "viewpoints");

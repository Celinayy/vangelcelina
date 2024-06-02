const mongoose = require('mongoose')

const hirdetesSchema = new mongoose.Schema({
	_id: {
		type: Number,
		required: true
	  },
	kategoria: {
		type: Number,
		default: 1,
		ref: "Kategoria"
	},
	cim: {
		type: String,
		required: true,
		unique: true,
		maxlength: [100, 'A cím nem tartalmazhat 100 karakternél többet!'],
	},
	leiras: {
		type: String,
		maxlength: [3000, 'A leírás nem tartalmazhat 3000 karakternél többet!'],
	},
	hirdetesDatuma: {
		type: Date,
		default: () => {
			return Date.now()
		}
	},
	serulesmentes: {
		type: Boolean
	},
	arFt: {
		type: Number,
		required: true
	},
	kepUrl: {
		type: String,
		maxlength: [300, 'A kép címe nem tartalmazhat 300 karakternél többet!'],
	}

})

module.exports = mongoose.model('Hirdetes', hirdetesSchema, 'hirdetesek') // telefonok névvel lesz létrehozva a kollekció.

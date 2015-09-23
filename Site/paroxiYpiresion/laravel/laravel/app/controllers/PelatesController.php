<?php

class PelatesController extends \BaseController {

	/**
	 * Display a listing of the resource.
	 *
	 * @return Response
	 */
	public function index()
	{
		//
	}


	/**
	 * Show the form for creating a new resource.
	 *
	 * @return Response
	 */
	public function create()
	{
		//
	}

			public function find()
				{
					$p_id = Input::get('p_id');
					$pelatis = Pelatis::find($p_id);
					//return $pelatis;
					return json_encode($pelatis);
				}
	/**
	 * Store a newly created resource in storage.
	 *
	 * @return Response
	 */
	public function store()
	{
		$pelatis = new Pelatis;

		$pelatis->Onoma = Input::get('Onoma');
		$pelatis->Epitheto = Input::get('Epitheto');
		$pelatis->Onoma_Miteras = Input::get('Onoma_Miteras');
		$pelatis->Onoma_Patera = Input::get('Onoma_Patera');
		$pelatis->Epaggelma = Input::get('Epaggelma');
		$pelatis->Tilefono_Oikias = Input::get('Tilefono_Oikias');
		$pelatis->Kinito_Tilefono = Input::get('Kinito_Tilefono');
		$pelatis->Hmerominia_Gennisis = Input::get('Hmerominia_Gennisis');
		$pelatis->Email = Input::get('Email');
		$pelatis->Dimos = Input::get('Dimos');
		$pelatis->Periferiaki_Enotita = Input::get('Periferiaki_Enotita');
		$pelatis->Periferia = Input::get('Periferia');
		$pelatis->Diefthinsi = Input::get('Diefthinsi');
		$pelatis->save();

		return Redirect::to('/pelates');
	}


	/**
	 * Display the specified resource.
	 *
	 * @param  int  $id
	 * @return Response
	 */
	public function show($id)
	{
		//
	}


	/**
	 * Show the form for editing the specified resource.
	 *
	 * @param  int  $id
	 * @return Response
	 */
	public function edit()
	{
		$p_id = Input::get('p_id');
		$pelatis = Pelatis::find($p_id);
		//return $pelatis;
		return json_encode($pelatis);
	}


	/**
	 * Update the specified resource in storage.
	 *
	 * @param  int  $id
	 * @return Response
	 */
	public function update()
	{
		$p_id = Input::get('p_id');
		$pelatis = Pelatis::find($p_id);

		$pelatis->Onoma = Input::get('Onoma');
		$pelatis->Epitheto = Input::get('Epitheto');
		$pelatis->Onoma_Miteras = Input::get('Onoma_Miteras');
		$pelatis->Onoma_Patera = Input::get('Onoma_Patera');
		$pelatis->Epaggelma = Input::get('Epaggelma');
		$pelatis->Tilefono_Oikias = Input::get('Tilefono_Oikias');
		$pelatis->Kinito_Tilefono = Input::get('Kinito_Tilefono');
		$pelatis->Hmerominia_Gennisis = Input::get('Hmerominia_Gennisis');
		$pelatis->Email = Input::get('Email');
		$pelatis->Dimos = Input::get('Dimos');
		$pelatis->Periferiaki_Enotita = Input::get('Periferiaki_Enotita');
		$pelatis->Periferia = Input::get('Periferia');
		$pelatis->Diefthinsi = Input::get('Diefthinsi');

		$pelatis->save();
		return Redirect::to('/pelates');
	}


	/**
	 * Remove the specified resource from storage.
	 *
	 * @param  int  $id
	 * @return Response
	 */
	public function destroy()
	{
		$p_id = Input::get('p_id');
		$pelatis = Pelatis::find($p_id);
		$pelatis->delete();
	

		return Redirect::to('/pelates');
	}


}

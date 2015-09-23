<?php

class RantevouController extends \BaseController {

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


	/**
	 * Store a newly created resource in storage.
	 *
	 * @return Response
	 */
	public function store()
	{
		$rantevou = new Rantevou;

		$rantevou->p_id = Input::get('p_id');
		$rantevou->ait_id = Input::get('ait_id');
		$rantevou->Thema = Input::get('Thema');
		$rantevou->Krisimotita = Input::get('Krisimotita');
		$rantevou->Hmerominia = Input::get('Hmerominia');
		$rantevou->Sxolia = Input::get('Sxolia');

		$rantevou->save();

		return Redirect::to('/rantevou');
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
		$rant_id = Input::get('rant_id');
		$rantevou = Rantevou::find($rant_id);
		//return $pelatis;
		return json_encode($rantevou);
	}


	/**
	 * Update the specified resource in storage.
	 *
	 * @param  int  $id
	 * @return Response
	 */
	public function update()
	{
		

		$rant_id = Input::get('rant_id');
		$rantevou = Rantevou::find($rant_id);

		$rantevou->p_id = Input::get('p_id');
		$rantevou->ait_id = Input::get('ait_id');
		$rantevou->Thema = Input::get('Thema');
		$rantevou->Krisimotita = Input::get('Krisimotita');
		$rantevou->Hmerominia = Input::get('Hmerominia');
		$rantevou->Sxolia = Input::get('Sxolia');

		$rantevou->save();

		return Redirect::to('/rantevou');

	}


	/**
	 * Remove the specified resource from storage.
	 *
	 * @param  int  $id
	 * @return Response
	 */
	public function destroy()
	{
		$rant_id = Input::get('rant_id');
		$rantevou = Rantevou::find($rant_id);
		$rantevou->delete();
	

		return Redirect::to('/rantevou');
	}


}

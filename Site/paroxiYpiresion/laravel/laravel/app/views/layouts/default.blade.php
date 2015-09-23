<!DOCTYPE html>

<html>
	<head>
		@include('includes.header')
	</head>
	
	<body>
			@include('includes.navbar')

		<div class="container">
			@yield('content')
			@include('includes.footer')
		</div>

		

		
	</body>
	
</html>
extends MeshInstance3D

@onready var matieral:Material = $".".get_surface_override_material(0)
@onready var leftHand:XRNode3D = $"../../XROrigin3D/LeftTrackedHand"
@onready var righthand:XRNode3D = $"../../XROrigin3D/RightTrackedHand"
var blue:Color = Color(0,0,1)
var white:Color = Color(1,1,1)
@export var minDistance:float = .2;


func _process(delta: float) -> void:
	
	if position.distance_to(leftHand.position) <= minDistance:
		matieral.albedo_color = white
	elif position.distance_to(righthand.position) <= minDistance:
		matieral.albedo_color = white
	else:
		matieral.albedo_color = blue

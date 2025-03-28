extends MeshInstance3D

@onready var matieral:Material = $"../BlueCube".get_surface_override_material(0)
@onready var leftHand:XRNode3D = $"../../XROrigin3D/LeftTrackedHand"
@onready var righthand:XRNode3D = $"../../XROrigin3D/RightTrackedHand"
@onready var audio:AudioStreamPlayer3D = $AudioStreamPlayer3D
@export var minDistance:float = .2;


func _process(delta: float) -> void:
	if position.distance_to(leftHand.position) <= minDistance && !audio.playing:
		audio.play()
	elif position.distance_to(righthand.position) <= minDistance && !audio.playing:
		audio.play()
		

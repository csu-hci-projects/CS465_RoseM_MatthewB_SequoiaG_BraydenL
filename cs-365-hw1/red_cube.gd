extends MeshInstance3D

@onready var leftHand:XRNode3D = $"../../XROrigin3D/LeftTrackedHand"
@onready var righthand:XRNode3D = $"../../XROrigin3D/RightTrackedHand"
@export var grabDistance:float = .3;
var leftAttached:bool = false
var rightAttached:bool = false
var offest:Vector3


func _process(delta: float) -> void:
	if leftAttached:
		position = leftHand.position + offest
	elif rightAttached:
		position = righthand.position + offest


func _on_left_hand_pose_pose_ended(p_name: String) -> void:
	leftAttached = false


func _on_left_hand_pose_pose_started(p_name: String) -> void:
	if p_name == "Fist" && position.distance_to(leftHand.position) <= grabDistance:
		leftAttached = true
		offest = -1*(position.distance_to(leftHand.position) * position.direction_to(leftHand.position))


func _on_right_hand_pose_pose_started(p_name: String) -> void:
	if p_name == "Fist" && position.distance_to(righthand.position) <= grabDistance:
		rightAttached = true
		offest = -1*(position.distance_to(righthand.position) * position.direction_to(righthand.position))
	pass # Replace with function body.


func _on_right_hand_pose_pose_ended(p_name: String) -> void:
	rightAttached = false

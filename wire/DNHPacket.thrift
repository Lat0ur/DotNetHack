struct DNHAuthResponse {
	1: i32 ID,
	2: string Message
}

service DNHService {
	DNHAuthResponse Authenticate(1: string userName, 2: string passwordHash)
}

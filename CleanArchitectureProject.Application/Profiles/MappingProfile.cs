using AutoMapper;
using CleanArchitectureProject.Application.DTOs.LeaveAllocation;
using CleanArchitectureProject.Application.DTOs.LeaveRequest;
using CleanArchitectureProject.Application.DTOs.LeaveType;
using CleanArchitectureProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureProject.Application.Profiles
{
    public class MappingProfile : Profile
    {
        // Ánh xạ giữa Entity <-> DTO
        public MappingProfile()
        {
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
        }
    }
}

/*
  - Dùng CreateMap<TSource, TDestination>() để thiết lập ánh xạ dữ liệu
  - Dùng ReverseMap() để cho phép ánh xạ 2 chiều giữa Entity và DTO.
 */

// - USE: Dùng khi gửi dữ liệu từ backend ra UI (GET API) hoặc khi nhận dữ liệu từ UI để lưu vào
// database (POST/PUT API).


/*
 - Entity chứa rất nhiều thông tin nhạy cảm, nếu trả về trực tiếp có thể lộ dữ liệu không mong muốn.
 -> Ví dụ: Nếu Entity User chứa cả password, nhưng bạn chỉ muốn trả về username, việc dùng DTO giúp ẩn thông tin không cần thiết.
 */

/*
 ** Tách biệt giữa tầng Domain và Application ** 
- Entity thuộc về Domain: Đây là lớp dữ liệu quan trọng, không nên thay đổi vì API hoặc UI yêu cầu định dạng khác.
- DTO thuộc về Application: Giúp kiểm soát dữ liệu gửi/nhận giữa các tầng, giúp tách biệt logic nghiệp vụ với giao diện.
 */


/* Khó mở rộng, bảo trì
- Nếu sau này API cần thay đổi cách hiển thị dữ liệu, việc dùng DTO giúp cập nhật mà không ảnh hưởng đến Entity.
- DTO giúp linh hoạt hơn khi API cần thêm trường, định dạng lại dữ liệu mà không làm thay đổi cấu trúc database.
 */